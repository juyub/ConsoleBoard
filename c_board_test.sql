CREATE TABLE c_board_test (
    ID NUMBER(10) PRIMARY KEY,
    TITLE VARCHAR2(100),
    CONTENT VARCHAR2(4000),
    DATECREATED DATE
);

CREATE SEQUENCE c_board_test_seq
START WITH     1
INCREMENT BY   1
NOCACHE;

ALTER TABLE c_board_test RENAME COLUMN ID TO BoardNo;
ALTER TABLE c_board_test RENAME COLUMN DATECREATED TO RegDate;

CREATE TABLE c_board_test (
    BoardNo NUMBER(10) PRIMARY KEY,
    TITLE VARCHAR2(100),
    CONTENT VARCHAR2(4000),
    RegDate DATE
);


SELECT * FROM c_board_test;

SELECT BOARDNO, TITLE, CONTENT,
       TO_CHAR(RegDate, 'yy/mm/dd HH24:MI:SS') AS RegDateTime
FROM c_board_test;


COMMIT;