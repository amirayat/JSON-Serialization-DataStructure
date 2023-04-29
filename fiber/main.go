package main

import (
	"context"
	"fmt"
	"log"
	"os"

	"github.com/gofiber/fiber/v2"
	"github.com/jackc/pgx/v5/pgxpool"
	"github.com/joho/godotenv"
	"gopkg.in/guregu/null.v4"
)

// Country struct

type Country struct {
	ID              int         `json:"id"`
	Name            string      `json:"name"`
	Iso3            string      `json:"iso3"`
	Iso2            string      `json:"iso2"`
	Numeric_code    string      `json:"numeric_code"`
	Phone_code      string      `json:"phone_code"`
	Capital         null.String `json:"capital"`
	Currency        string      `json:"currency"`
	Currency_name   string      `json:"currency_name"`
	Currency_symbol string      `json:"currency_symbol"`
	Tld             string      `json:"tld"`
	Native          null.String `json:"native"`
	Region          null.String `json:"region"`
	Subregion       null.String `json:"subregion"`
	Timezones       string      `json:"timezones"`
	Translations    string      `json:"translations"`
	Latitude        string      `json:"latitude"`
	Longitude       string      `json:"longitude"`
	Emoji           string      `json:"emoji"`
	EmojiU          string      `json:"emojiU"`
}

// Countries struct
type Countries struct {
	Countries []Country `json:"countries"`
}


func main() {
	// Connect with database
	err := godotenv.Load(".env")
	if err != nil {
		log.Fatalf("Error loading .env file")
	}
	DATABASE_URL := os.Getenv("DATABASE_URL")
	dbpool, err := pgxpool.New(context.Background(), DATABASE_URL)
	if err != nil {
		fmt.Fprintf(os.Stderr, "Unable to create connection pool: %v\n", err)
		os.Exit(1)
	}

	// Create a Fiber app
	app := fiber.New()

	// Get all records from postgreSQL
	app.Get("/countries/", func(c *fiber.Ctx) error {
		// Select all Country(s) from database
		rows, err := dbpool.Query(context.Background(), "SELECT * FROM countries;")
		if err != nil {
			return c.Status(500).SendString(err.Error())
		}
		defer rows.Close()
		result := Countries{}

		for rows.Next() {
			country := Country{}
			if err := rows.Scan(
				&country.ID,
				&country.Name,
				&country.Iso3,
				&country.Iso2,
				&country.Numeric_code,
				&country.Phone_code,
				&country.Capital,
				&country.Currency,
				&country.Currency_name,
				&country.Currency_symbol,
				&country.Tld,
				&country.Native,
				&country.Region,
				&country.Subregion,
				&country.Timezones,
				&country.Translations,
				&country.Latitude,
				&country.Longitude,
				&country.Emoji,
				&country.EmojiU); err != nil {
				return err // Exit if we get an error
			}

			// Append Country to Countries
			result.Countries = append(result.Countries, country)
		}
		// Return Countries in JSON format
		return c.JSON(result)
	})

	log.Fatal(app.Listen(":8000"))
}
