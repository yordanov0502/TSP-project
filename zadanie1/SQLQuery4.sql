--Select c.RegNomer,c.Mark,o.KodTaxi  From Orders o
--Join Cars c ON o.KodTaxi=c.KodTaxi
--Where o.KodTaxi='0001';

--SELECT o.KodTaxi,
  --SUM(o.Fare) AS total_score
--FROM Orders o
--Join Cars c ON o.KodTaxi=c.KodTaxi
--GROUP BY o.KodTaxi
--ORDER BY SUM(o.Fare) DESC;

--Select c.RegNomer,c.Mark,o.KodTaxi,SUM(o.Fare) AS total_SUM From Orders o
--Join Cars c ON o.KodTaxi=c.KodTaxi
--Where o.OrdTime<GETDATE();

