--creating indexes
drop index if exists hpds_indexed1;
CREATE INDEX hpds_indexed1 ON hpds_indexed(continent);

drop index if exists hpds_indexed2;
CREATE INDEX hpds_indexed2 ON hpds_indexed(amount);

drop index if exists hpds_indexed3;
CREATE INDEX hpds_indexed3 ON hpds_indexed(sector);
