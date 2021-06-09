CREATE TABLE [dbo].[NewMotionTable] (
    [Id]           INT            NOT NULL,
    [creationTime] DECIMAL (38)   NOT NULL,
    [fileName]     VARCHAR (50)   NOT NULL,
    [path]         VARCHAR (2056) NOT NULL,
    [camera]       VARCHAR (38)  NOT NULL,
    PRIMARY KEY CLUSTERED ([creationTime] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_NewMotionTable_Column]
    ON [dbo].[NewMotionTable]([creationTime] ASC);

