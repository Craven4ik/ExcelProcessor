--Блок 1
--Воспользоваться ресурсом https://www.w3schools.com/sql/trysql.asp?filename=trysql_editor
--1. Вывести тз таблицы Customers все записи где City  = London
--2. Получить сумму по полю Price из таблицы Products
--3. Используя таблицы Orders, OrderDetails и Products вывести номер заказа и наименование продукта 

--Task 1
SELECT * FROM Customers WHERE City = "London";

--Task 2
SELECT SUM(Price) FROM Products;

--Task 3
SELECT Orders.OrderID, Products.ProductName
FROM ((Orders
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID)
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID);



--Блок 2
--1. Получить все записи из таблицы Operations у которых Registering Date находится в промежутке между 1 октября 2023 и 31 октября 2023
--2. Используя таблицы Operations и Items вывести список операций и Article c Brand для каждого товара 
--3. Используя таблицы Operations и Items найти все товары по которым не было ни одной операции
--4. Отсортировать строки в таблице Operations по полю Quantity по возрастанию 
--5. Получить список уникальных ItemNumber из таблицы Operations для Registering Date более 1.12.23
--6. Вывести из таблицы Operations и Items поля Article и Quantity с суммой по полю Quantity

--Task 1
SELECT * FROM Operations WHERE "Registering Date" > '2023-10-01' AND "Registering Date" < '2023-10-31';

--Task 2.1 (если нужно вывести товары, по которым не было операций)
SELECT Operations.*, Items.Article, Items.Brand FROM Items
LEFT JOIN Operations ON Items.ItemNumber = Operations.ItemNumber;

--Task 2.2 (если нужно вывести только те товары, по которым были операции)
SELECT Operations.*, Items.Article, Items.Brand FROM Items
LEFT JOIN Operations ON Items.ItemNumber = Operations.ItemNumber;

--Task 3
SELECT Items.* FROM Items
LEFT JOIN Operations ON Items.ItemNumber = Operations.ItemNumber
WHERE Operations.ItemNumber IS NULL;

--Task 4
SELECT * FROM Operations ORDER BY Quantity;

--Task 5
SELECT DISTINCT Items.ItemNumber FROM Operations WHERE "Registering Date" > '2023-12-01';

--Task 6
SELECT Items.Article, SUM(Operations.Quantity) AS TotalQuantity FROM Items
INNER JOIN Operations ON Items.ItemNumber = Operations.ItemNumber GROUP BY Items.Article;