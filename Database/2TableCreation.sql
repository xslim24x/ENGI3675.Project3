-- Delete data tables so they can be created without conflicts
drop table if exists hpds cascade;
drop table if exists hpds_indexed cascade;

-- Create new table with constraints
create table hpds 
(
	Id serial primary key,
	years int not null,
	continent text not null check(length(continent)>0),
	region text not null check(length(region)>0),
	sector text not null check(length(sector)>0),
	amount float not null
);
create table hpds_indexed
(
	Id serial primary key,
	years int not null,
	continent text not null check(length(continent)>0),
	region text not null check(length(region)>0),
	sector text not null check(length(sector)>0),
	amount float not null
);

-- Add appropriate comments to tables and columns

comment on table hpds is 'Information on hpds.';
comment on column hpds.Id is 'The hpds Id.';
comment on column hpds.years is 'the year hpds took place';
comment on column hpds.continent is 'The continent of hpds';
comment on column hpds.region is 'the region of hpds';
comment on column hpds.sector is 'the sectors of the hpds';
comment on column hpds.amount is 'the amount of money spent on hpds';

comment on table hpds_indexed is 'The coninuation of table hpds';
comment on column hpds_indexed.Id is 'The hpds_indexed Id.';
comment on column hpds_indexed.years is 'the year hpds_indexed took place';
comment on column hpds_indexed.continent is 'The continent of hpds_indexed';
comment on column hpds_indexed.region is 'the region of hpds_indexed';
comment on column hpds_indexed.sector is 'the sectors of the hpds_indexed';
comment on column hpds_indexed.amount is 'the amount of money spent on hpds_indexed';