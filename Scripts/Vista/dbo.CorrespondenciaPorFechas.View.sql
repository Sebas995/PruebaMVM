USE [PRUEVAMVM]
GO
/****** Object:  View [dbo].[CorrespondenciaPorFechas]    Script Date: 5/9/2021 5:40:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CorrespondenciaPorFechas]
AS
SELECT NumeroRadicado FROM CORRESPONDENCIA where FechaCreacion BETWEEN '2021-05-05' AND '2021-05-15'
GO
