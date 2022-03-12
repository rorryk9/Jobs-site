CREATE DATABASE jobs;

USE jobs;

-- drop table itjobs;

CREATE TABLE itjobs (
    job_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL,
    opisanie VARCHAR(3000)
);

CREATE TABLE casheirjobs (
    job_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL,
    opisanie VARCHAR(3000)
);

CREATE TABLE enjeneerjobs (
    job_id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(30) NOT NULL,
    opisanie VARCHAR(3000)
);
