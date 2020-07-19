CREATE TABLE IF NOT EXISTS category_audit (
	audit_id BIGSERIAL,
	resource varchar(20) not null,
	resource_id int not null,
	update_action varchar(20) not null,
	updated_on varchar(50) not null,
	updated_by varchar(20) not null,
	CONSTRAINT "PK_AuditID" PRIMARY KEY (audit_id)
)

