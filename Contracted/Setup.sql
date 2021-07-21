CREATE TABLE job(
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Last Update',
    name VARCHAR(255) NOT NULL COMMENT 'Job Name',
    description VARCHAR(255) NOT NULL COMMENT 'Job Description',
    currentBid int NOT NULL default 0 COMMENT 'currents bids',
    completed TINYINT default 0 comment 'job completed',
    creatorId VARCHAR(255) NOT NULL COMMENT "FK: User Account",
    FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';






CREATE TABLE bids(
    id int NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Last Update',
    accountId VARCHAR(255) NOT NULL COMMENT 'FK: Contracter Account',
    jobId int NOT NULL comment 'FK: Job',
    bidAmount int NOT NULL COMMENT 'Bid Amount',
    FOREIGN KEY(accountId) REFERENCES Accounts(id) ON DELETE CASCADE,
    FOREIGN KEY(jobId) REFERENCES job(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

