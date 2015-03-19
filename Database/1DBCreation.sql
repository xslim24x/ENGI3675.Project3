--Initialize starting conditions by deleting database
drop database if exists "Assignment3";

--Initilize User
drop role if exists "Assignment3";
create role "Assignment3" login;
comment on role "Assignment3" is 'Resctricted ISS app pool user';

--Creating Database and granting permissions
create database "Assignment3";
comment on database "Assignment3" is 'Database for Assigment3';

grant connect on database "Assignment3" to "Assignment3";
