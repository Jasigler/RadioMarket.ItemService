CREATE TABLE "Categories" (
	category_id BIGSERIAL,
	name varchar(20) NOT NULL,
	parent_id int,
	is_active bool NOT NULL,
	CONSTRAINT "PK_Category" PRIMARY KEY (category_id)
)

insert into public."Categories" (name, parent_id, is_active) 
values 
('Amateur', null, true),
('Vintage', null, true), 
('Maker Shields', null, true),
('Parts', null, true),
('Miscellaneous', null, true),
/* Amateur sub-categories */
('Antique', 1, true),
('HF Transceivers', 1, true),
('VHF/UHF Transceivers', 1, true),
('Hand-Held', 1, true),
('QRP', 1, true),
('Kits', 1, true),
('SDR', 1, true),
/* Vintage sub-categories */
('Pre-1930', 2, true),
('Tube', 2, true),
('Solid-State', 2, true),
('Military', 2, true),
 
/* Maker Shield sub-categories*/
('Arduino-Specific', 3, true),
('Universal', 3, true),
/* Parts sub-categories */
('Tubes', 4, true),
('Coils', 4, true),
('Capacitors', 4, true),
('Inductors', 4, true),
('Fuses', 4, true),
('Transistors', 4, true),
('Misc Components', 4, true)







