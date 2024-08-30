CREATE TABLE "countries" (
  "id" BIGSERIAL PRIMARY KEY,
  "name" varchar(30) NOT NULL,
  "code" varchar(5) UNIQUE NOT NULL,
  "created_at" timestamptz NOT NULL DEFAULT (now()),
  "updated_at" timestamptz NOT NULL DEFAULT (now()),
);

CREATE INDEX idx_countries_name ON "countries" ("name");

CREATE TABLE "clients" (
  "id" BIGSERIAL PRIMARY KEY,
  "name" varchar(30) NOT NULL,
  "last_name" varchar(30) NOT NULL,
  "country_id" bigint NOT NULL,
  "created_at" timestamptz NOT NULL DEFAULT (now()),
  "updated_at" timestamptz NOT NULL DEFAULT (now()),
  CONSTRAINT fk_country
    FOREIGN KEY ("country_id") 
    REFERENCES "countries" ("id")
    ON DELETE RESTRICT
);

CREATE INDEX idx_clients_country_id ON "clients" ("country_id");
CREATE INDEX idx_clients_name_last_name ON "clients" ("name", "last_name");

CREATE TABLE "phones" (
  "id" BIGSERIAL PRIMARY KEY,
  "number" varchar(12) UNIQUE NOT NULL,
  "country_id" bigint NOT NULL,
  "client_id" bigint NOT NULL,
  "created_at" timestamptz NOT NULL DEFAULT (now()),
  "updated_at" timestamptz NOT NULL DEFAULT (now()),
  CONSTRAINT fk_country
    FOREIGN KEY ("country_id") 
    REFERENCES "countries" ("id")
    ON DELETE RESTRICT,
  CONSTRAINT fk_client
    FOREIGN KEY ("client_id") 
    REFERENCES "clients" ("id")
    ON DELETE CASCADE
);

CREATE INDEX idx_phones_country_id ON "phones" ("country_id");
CREATE INDEX idx_phones_client_id ON "phones" ("client_id");

CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
   NEW.updated_at = now();
   RETURN NEW;
END;
$$ language 'plpgsql';

CREATE TRIGGER update_countries_updated_at BEFORE UPDATE
ON "countries" FOR EACH ROW EXECUTE PROCEDURE 
update_updated_at_column();

CREATE TRIGGER update_clients_updated_at BEFORE UPDATE
ON "clients" FOR EACH ROW EXECUTE PROCEDURE 
update_updated_at_column();

CREATE TRIGGER update_phones_updated_at BEFORE UPDATE
ON "phones" FOR EACH ROW EXECUTE PROCEDURE 
update_updated_at_column();