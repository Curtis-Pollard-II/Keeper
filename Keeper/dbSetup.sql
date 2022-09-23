-- ACCOUNTS
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

SELECT * FROM accounts;



-- KEEPS
CREATE Table IF NOT EXISTS keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description TEXT NOT NULL, 
  img VARCHAR(255) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  kept INT NOT NULL DEFAULT 0,

  Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

DROP TABLE keeps;

-- Keeps Create
INSERT INTO keeps
(name, description, img, creatorId)
VALUES
("Hair Style", "less is more", "https://i.pinimg.com/originals/22/ce/2e/22ce2e264d31858b3f39a597a0dbe104.jpg", "6328c5a5f170ebe2ab203b70");

-- Keeps Get ALL
SELECT 
k.*,
a.*
FROM keeps k
JOIN accounts a ON a.id = k.creatorId;

-- Keep Get One
SELECT
  k.*,
  a.*
FROM keeps k
JOIN accounts a ON a.id = k.creatorId
WHERE k.id = 1;

-- Keep Update
UPDATE keeps SET
  name = "hey o",
  description = "is there a problem with being bald",
  img = "https://media.istockphoto.com/photos/completely-bald-man-head-picture-id626510790?k=20&m=626510790&s=612x612&w=0&h=5dbNIsbJDHRczElO6D52yl2LsHicaAxAQGsK0q6kK3Q="
WHERE id = 1;