import * as dotenv from 'dotenv'
import express from 'express'
import pkg from 'pg';
import cluster from 'cluster'
const { Pool } = pkg;

dotenv.config()

const pool = new Pool({
  host: process.env.DB_HOST,
  port: process.env.DB_PORT,
  database: process.env.DB_NAME,
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
  max: 100,
  idleTimeoutMillis: 3000,
  connectionTimeoutMillis: 2000,
})

if (cluster.isPrimary) {
  // Fork workers.
  for (let i = 0; i < 8; i++) {
    cluster.fork();
  }

  cluster.on('exit', (worker, code, signal) =>
    console.log('worker ' + worker.pid + ' died'));
} else {
  const app = express();
  
  app.get('/countries/', (request, response) => {
    pool.query('SELECT * FROM countries', (error, results) => {
      if (error) {
        throw error
      }
      response.status(200).json(results.rows)
    })
  })
  
  app.listen(8000)
}