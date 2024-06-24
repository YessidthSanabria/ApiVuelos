##Insertar Datos en tabla DESTINO

INSERT INTO public."Destino"("Id", "IdDestino", "NombreDestino")
VALUES 
	("edaa6322-c5fb-4c1e-ae14-a59d2327da5e", 1, "JFK (NuevaYork, EE.UU)"),
	("8c55b7be-bd36-434c-b91e-d560cd7064f6", 2, "MIA (Miami, EE.UU)"),
	("d8279c5c-ea18-424f-99c3-c73530fbf98c", 3, "MDE (Medellín, Colombia)"),
	("e7c5e894-2e92-45e4-b22b-7b28786167dc", 4, "MCO (Orlando, EE.UU)"),
	("dda0d6c6-6a28-4b17-aed8-2934c6701aa8", 5, "MCO - Aeropuerto Internacional de Orlando (EE.UU)"),
	("1b21623f-a73f-4778-8a17-bc14c0e85cd5", 6, "SDQ (Santo Domingo, Republica Dominicana)"),
	("4151766f-0e6c-4c1e-9058-72d1426a4da5", 7, "PUJ (Punta Cana, República Dominicana)"),
	("4fa4720b-ca9c-4578-bd13-0b2800c80167", 8, "FLL (Fort Lauderdale, EE.UU)");

##Insertar Datos en tabla ORIGEN

INSERT INTO public."Origen"("Id", "IdOrigen", "NombreOrigen")
VALUES 
	("964bc9e2-d71e-434b-8318-37466de56cd8", 1, "SDQ - Aeropuerto Internacional de Las Américas (República Dominicana)"),
	("ca57cda2-0a93-451f-86d0-3fa0157384da", 2, "PUJ - Aeropuerto Internacional de Punta Cana (República Dominicana)"),
	("b1626e80-9de0-4123-967b-0732332d8fc8", 3, "MCO - Aeropuerto Internacional de Orlando (EE:UU)"),
	("f9f78d5f-b011-49d6-9091-f3e2feed46d0", 4, "MIA - Aeropuerto Internacional de Miami (EE.UU)"),
	("548a5b96-1069-4a39-85e3-d5cc0d1efb09", 5, "JFK - Aeropuerto Internacional John F. Kennedy (Nueva York, EE.UU)"),
	("b08f87ee-6d61-4e25-a3e6-312337164f56", 6, "FLL - Aeropuerto Internacional de Fort Lauderdale-Hollywood (EE.UU)"),
	("e4562b20-de94-47d8-a9fb-bfa75c1267d3", 7, "MDE - Aeropuerto Internacional José María Córdova (Medellín, Colombia)");

##Crear extensión en postgresl para uuid_generate_v4

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

##Insertar Datos en tabla VUELOS

INSERT INTO public."Vuelos" ("Id", "IdOrigen", "IdDestino", "IdVuelo", "FechaLlegada", "FechaSalida")
VALUES
    (uuid_generate_v4(), '964bc9e2-d71e-434b-8318-37466de56cd8', 'edaa6322-c5fb-4c1e-ae14-a59d2327da5e', 1, '2024-06-07 10:00:00', '2024-06-07 12:00:00'),
    (uuid_generate_v4(), '964bc9e2-d71e-434b-8318-37466de56cd8', '8c55b7be-bd36-434c-b91e-d560cd7064f6', 1, '2024-06-08 10:00:00', '2024-06-08 12:00:00'),
    (uuid_generate_v4(), '964bc9e2-d71e-434b-8318-37466de56cd8', 'd8279c5c-ea18-424f-99c3-c73530fbf98c', 1, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'ca57cda2-0a93-451f-86d0-3fa0157384da', 'edaa6322-c5fb-4c1e-ae14-a59d2327da5e', 2, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'ca57cda2-0a93-451f-86d0-3fa0157384da', 'e7c5e894-2e92-45e4-b22b-7b28786167dc', 2, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'ca57cda2-0a93-451f-86d0-3fa0157384da', 'd8279c5c-ea18-424f-99c3-c73530fbf98c', 2, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'ca57cda2-0a93-451f-86d0-3fa0157384da', 'dda0d6c6-6a28-4b17-aed8-2934c6701aa8', 2, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'b1626e80-9de0-4123-967b-0732332d8fc8', '1b21623f-a73f-4778-8a17-bc14c0e85cd5', 3, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'b1626e80-9de0-4123-967b-0732332d8fc8', '4151766f-0e6c-4c1e-9058-72d1426a4da5', 3, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'b1626e80-9de0-4123-967b-0732332d8fc8', '8c55b7be-bd36-434c-b91e-d560cd7064f6', 3, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'f9f78d5f-b011-49d6-9091-f3e2feed46d0', '1b21623f-a73f-4778-8a17-bc14c0e85cd5', 4, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'f9f78d5f-b011-49d6-9091-f3e2feed46d0', '4151766f-0e6c-4c1e-9058-72d1426a4da5', 4, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'f9f78d5f-b011-49d6-9091-f3e2feed46d0', 'edaa6322-c5fb-4c1e-ae14-a59d2327da5e', 4, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'f9f78d5f-b011-49d6-9091-f3e2feed46d0', '4fa4720b-ca9c-4578-bd13-0b2800c80167', 4, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), '548a5b96-1069-4a39-85e3-d5cc0d1efb09', '1b21623f-a73f-4778-8a17-bc14c0e85cd5', 5, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), '548a5b96-1069-4a39-85e3-d5cc0d1efb09', '4151766f-0e6c-4c1e-9058-72d1426a4da5', 5, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), '548a5b96-1069-4a39-85e3-d5cc0d1efb09', '8c55b7be-bd36-434c-b91e-d560cd7064f6', 5, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'b08f87ee-6d61-4e25-a3e6-312337164f56', '8c55b7be-bd36-434c-b91e-d560cd7064f6', 6, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'e4562b20-de94-47d8-a9fb-bfa75c1267d3', '1b21623f-a73f-4778-8a17-bc14c0e85cd5', 7, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'e4562b20-de94-47d8-a9fb-bfa75c1267d3', '4151766f-0e6c-4c1e-9058-72d1426a4da5', 7, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'e4562b20-de94-47d8-a9fb-bfa75c1267d3', 'e7c5e894-2e92-45e4-b22b-7b28786167dc', 7, '2024-06-09 10:00:00', '2024-06-09 12:00:00'),
	(uuid_generate_v4(), 'e4562b20-de94-47d8-a9fb-bfa75c1267d3', '8c55b7be-bd36-434c-b91e-d560cd7064f6', 7, '2024-06-09 10:00:00', '2024-06-09 12:00:00');



















