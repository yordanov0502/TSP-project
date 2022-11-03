CREATE TABLE [dbo].[Orders] (
    [NumOrd]   INT            IDENTITY (1, 1) NOT NULL,
    [KodTaxi]  NVARCHAR (4)   NOT NULL,
    [Addres]   NVARCHAR (50)  NOT NULL,
    [OrdTime]  DATETIME       NOT NULL,
    [Distance] DECIMAL (5, 3) NOT NULL,
    [Fare]     DECIMAL (5, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([NumOrd] ASC),
    CONSTRAINT [FK_ORDERS_TO_CARS] FOREIGN KEY ([KodTaxi]) REFERENCES [dbo].[Cars] ([KodTaxi])
);

