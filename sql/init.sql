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

INSERT INTO countries (name, code) VALUES
('Argentina', '+54'),
('Brasil', '+55'),
('Chile', '+56'),
('Colombia', '+57'),
('México', '+52'),
('Perú', '+51'),
('Uruguay', '+598'),
('Venezuela', '+58');

INSERT INTO clients (name, last_name, country_id) VALUES
('Juan', 'Pérez', 1),
('María', 'González', 2),
('Carlos', 'Rodríguez', 3),
('Ana', 'Martínez', 4),
('Luis', 'López', 5),
('Laura', 'Fernández', 6),
('Diego', 'García', 7),
('Sofía', 'Torres', 8),
('Andrés', 'Ramírez', 1),
('Valentina', 'Herrera', 2),
('Javier', 'Castro', 3),
('Camila', 'Vargas', 4),
('Fernando', 'Morales', 5),
('Gabriela', 'Ortiz', 6),
('Ricardo', 'Silva', 7),
('Isabella', 'Rojas', 8),
('Miguel', 'Mendoza', 1),
('Lucía', 'Flores', 2),
('Eduardo', 'Acosta', 3),
('Mariana', 'Gutiérrez', 4);

INSERT INTO phones (number, country_id, client_id) VALUES
('11234567', 1, 1),
('21987654', 2, 2),
('32123456', 3, 3),
('43210987', 4, 4),
('55544332', 5, 5),
('66778899', 6, 6),
('87654321', 7, 7),
('12345678', 8, 8),
('11223344', 1, 9),
('22334455', 2, 10),
('33445566', 3, 11),
('44556677', 4, 12),
('66778899', 5, 13),
('77889900', 6, 14),
('98765432', 7, 15),
('23456789', 8, 16),
('11998877', 1, 17),
('22887766', 2, 18),
('33776655', 3, 19),
('44665544', 4, 20),
('77665544', 5, 1),
('88776655', 6, 2),
('99887766', 7, 3),
('34567890', 8, 4),
('12345678', 1, 5),
('23456789', 2, 6),
('34567890', 3, 7),
('45678901', 4, 8),
('88776655', 5, 9),
('99887766', 6, 10);