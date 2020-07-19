CREATE OR REPLACE FUNCTION deactivate_category()
	RETURNS trigger AS $$
		BEGIN
		INSERT INTO audit(resource, resource_id, update_action, updated_on, updated_by)
		Values ('category', old.id , 'deactivate', current_timestamp, current_user );
		RETURN new;
	END;
	$$
	LANGUAGE'plpgsql';
	
	CREATE TRIGGER deactivate_category
		BEFORE UPDATE ON categories
		FOR EACH ROW
		WHEN (new.is_active = false)
		EXECUTE PROCEDURE deactivate_category()
