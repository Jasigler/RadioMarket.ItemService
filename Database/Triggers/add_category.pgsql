CREATE OR REPLACE FUNCTION add_category()
	RETURNS trigger AS $$
		BEGIN
		INSERT INTO category_audit(resource, resource_id, update_action, updated_on, updated_by)
		Values ('category', new.id , 'create', current_timestamp, current_user );
		RETURN new;
	END;
	$$
	LANGUAGE'plpgsql';
	
	CREATE TRIGGER add_category
		BEFORE INSERT ON Category
		FOR EACH ROW
		EXECUTE PROCEDURE add_category()


