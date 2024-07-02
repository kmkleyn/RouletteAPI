CREATE OR ALTER PROCEDURE pr_GetOrderSummary  @StartDate DATE, @EndDate DATE, @EmployeeID INT NULL, @CustomerID NVARCHAR(5) NULL
AS

WITH ORDER_DETAILS (TotalOrderSum, OrderID, ProductID) AS 
(
	SELECT SUM(UnitPrice * Quantity - Discount), OrderID, ProductID
	FROM [Order Details]
	GROUP BY OrderID, ProductID
)

SELECT 

e.TitleOfCourtesy + ' ' + e.FirstName + ' ' + e.LastName AS EmployeeFullName,
s.CompanyName AS ShipperCompanyName,
c.CompanyName AS CustomerCompanyName,
COUNT(o.OrderID) AS NumberOfOrders,
o.OrderDate AS OrderDate,
SUM(o.Freight) AS TotalFreightCost,
COUNT(distinct od.ProductID) AS NumberOfDifferentProducts,
SUM(od.TotalOrderSum) AS TotalOrderValue

FROM Orders o 
INNER JOIN ORDER_DETAILS od ON o.OrderID = od.OrderID
LEFT JOIN Customers c ON c.CustomerID = o.CustomerID
LEFT JOIN Employees e ON e.EmployeeID = o.EmployeeID
LEFT JOIN Shippers s ON s.ShipperID = o.ShipVia

WHERE c.CustomerID = ISNULL(@CustomerID, c.CustomerID)  
AND e.EmployeeID = ISNULL(@EmployeeID, e.EmployeeID) 
AND o.OrderDate >= @StartDate 
AND o.OrderDate <= @EndDate

GROUP BY e.TitleOfCourtesy + ' ' + e.FirstName + ' ' + e.LastName,
s.CompanyName,
c.CompanyName,
o.OrderDate

GO

