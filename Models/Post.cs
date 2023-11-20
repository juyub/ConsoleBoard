/*
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
*/

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public DateTime DateCreated { get; set; }
}