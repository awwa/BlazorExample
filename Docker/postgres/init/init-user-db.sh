#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE ROLE root WITH LOGIN PASSWORD 'postgres';
    ALTER ROLE root SUPERUSER CREATEDB;
    CREATE DATABASE root;
EOSQL