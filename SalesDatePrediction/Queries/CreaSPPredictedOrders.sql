CREATE PROCEDURE GetNextPredictedOrders
AS
BEGIN
    SET NOCOUNT ON;

    -- Tabla temporal para almacenar los d�as entre pedidos por cliente
    CREATE TABLE #TempOrderIntervals (
        CustId INT,
        DaysBetweenOrders INT
    );

    -- Insertar las diferencias de d�as entre pedidos
    INSERT INTO #TempOrderIntervals (CustId, DaysBetweenOrders)
    SELECT 
        CustId,
        DATEDIFF(DAY, PreviousOrderDate, OrderDate) AS DaysBetweenOrders
    FROM (
        SELECT 
            o.CustId,
            o.OrderDate,
            LAG(o.OrderDate) OVER (PARTITION BY o.CustId ORDER BY o.OrderDate) AS PreviousOrderDate
        FROM Sales.Orders o
    ) AS OrderDifferences
    WHERE PreviousOrderDate IS NOT NULL;

    -- Tabla temporal para el �ltimo pedido y el promedio de d�as entre pedidos
    CREATE TABLE #TempOrderData (
        CustId INT,
        LastOrderDate DATE,
        AvgDaysBetweenOrders INT
    );

    INSERT INTO #TempOrderData (CustId, LastOrderDate, AvgDaysBetweenOrders)
    SELECT 
        o.CustId,
        MAX(o.OrderDate) AS LastOrderDate,
        AVG(DaysBetweenOrders) AS AvgDaysBetweenOrders
    FROM Sales.Orders o
    LEFT JOIN #TempOrderIntervals toi ON o.CustId = toi.CustId
    GROUP BY o.CustId;

    -- Obtener los clientes y su pr�xima orden estimada
    SELECT 
        c.ContactName AS CustomerName,
        tod.LastOrderDate,
        DATEADD(DAY, COALESCE(tod.AvgDaysBetweenOrders, 30), tod.LastOrderDate) AS NextPredictedOrder
    FROM Sales.Customers c
    LEFT JOIN #TempOrderData tod ON c.CustId = tod.CustId
    ORDER BY NextPredictedOrder;

    -- Eliminar las tablas temporales
    DROP TABLE #TempOrderIntervals;
    DROP TABLE #TempOrderData;
END;
