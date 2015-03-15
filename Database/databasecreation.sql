drop database if exists "Assignment3";

drop role if exists "Assignment3";
create role "Assignment3" login;
comment on role "Assignment3" is 'Resctricted ISS app pool user';

drop role if exists "George";
create role "George" login superuser;
comment on role "George" is 'Personal developer superuser';

create database "Assignment3";
comment on database "Assignment3" is 'Database for Assigment3';

grant connect on database "Assignment3" to "Assignment3";
