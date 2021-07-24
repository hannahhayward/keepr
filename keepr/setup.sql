CREATE TABLE keeps (  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    creatorId VARCHAR(255) NOT NULL COMMENT ' Profile id',
    name VARCHAR(255) NOT NULL COMMENT 'keep name',
    description VARCHAR(255) COMMENT 'keep description',
    img VARCHAR(255) COMMENT 'keep image url',
    views INT COMMENT 'keep views',
    shares INT COMMENT 'keep shares',
    keeps INT COMMENT 'keeps'
) default charset utf8 comment '';
CREATE TABLE accounts (  
    id VARCHAR(255) NOT NULL primary key comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'created at',
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated at',
    name VARCHAR(255) NOT NULL COMMENT 'profile username',
    picture VARCHAR(255) COMMENT 'profile picture url',
    email VARCHAR(255) COMMENT 'account email'
) default charset utf8 comment '';
CREATE TABLE vaults (  
    id int AUTO_INCREMENT NOT NULL primary key comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'created at',
    updateAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'updated at',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: account id',
    name VARCHAR(255) NOT NULL COMMENT 'vault username',
    description VARCHAR(255) COMMENT 'vault description',
    isPrivate TINYINT COMMENT 'privacy',
    FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';
DROP Table accounts;
SELECT * FROM keeps;