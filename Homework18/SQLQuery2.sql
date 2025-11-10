USE [TSQL2012]

---- N1 -----

select cus.contactname as Customer_Name , 
cus.city as Customer_city,
ord.orderdate as Customer_Orderdate
from [Sales].[Customers] cus
join [Sales].[Orders] ord on ord.custid = cus.custid
where city in ('Madrid','London')


---- N2 -----

select prod.productname as Product_Name ,
prod.unitprice as Product_price,
cat.categoryname as Product_Category
from [Production].[Products] prod
join [Production].[Categories] cat on prod.categoryid = cat.categoryid
where prod.unitprice between 20 and 40


---- N3 -----


select emp.lastname as SalesManager_LastName,
emp.firstname as SalesManager_FirstName,
ord.orderid as SalesManager_Orderid
from [HR].[Employees] emp
join [Sales].[Orders] ord on ord.empid = emp.empid
where emp.title = 'Sales Manager'


---- N4 -----

select ord.orderdate as Order_Date,
cus.contactname as Customer_Name,
cus.city as Customer_City,
cus.postalcode as Customer_PostalCode
from [Sales].[Orders] ord
join [Sales].[Customers] cus on ord.custid = cus.custid
where YEAR(orderdate) = '2007'

---- N5 -----

select distinct ord.shipcity as Cities 
from [HR].[Employees] emp
join [Sales].[Orders] ord on emp.empid = ord.empid
where emp.lastname = 'Cameron'


---- N6 -----

select ord.orderid,ord.shipcountry,ord.shipcity
from [Sales].[Orders] ord
where ord.shipcountry in ('Germany','Austria')


---- N7 ----- 

select * from [Production].[Products] prod
join [Sales].[OrderDetails] ord on prod.productid = ord.productid
join [Production].[Suppliers] sup on prod.supplierid = sup.supplierid
where ord.discount > 0 and sup.city = 'Tokyo'

---- N8 ----- 

select prod.productname,cat.categoryname,cat.description from [Production].[Products] prod
join [Production].[Categories] cat on prod.categoryid = cat.categoryid
join [Production].[Suppliers] sup on prod.supplierid = sup.supplierid
where cat.categoryname in ('Beverages','Seafood') and sup.country = 'Japan'

---- N9 ----- 
select emp.firstname,emp.lastname ,ship.companyname from [HR].[Employees] emp 
join [Sales].[Orders] ord on emp.empid = ord.empid
join [Sales].[Shippers] ship on ord.shipperid = ship.shipperid
where YEAR(ord.orderdate) = '2007' and (
(emp.firstname = 'Sara' and emp.lastname = 'Davis') or
(emp.firstname = 'Maria' and emp.lastname = 'Cameron')
)


---- N10 ----- 

select prod.productname,cat.categoryname from [Production].[Suppliers] sup
join [Production].[Products] prod on sup.supplierid = prod.supplierid
join [Production].[Categories] cat on prod.categoryid = cat.categoryid
where sup.country = 'USA' and cat.categoryname not in ('Beverages','Seafood')



---- N11 ----- 

select ord.orderid,
emp.lastname as Employee_LastName,emp.firstname as Employee_FirstName ,emp.city as Employee_city,
cus.contactname as Customer_Name,cus.city  as Customer_City
from [HR].[Employees] emp
join [Sales].[Orders] ord on emp.empid = ord.empid
join [Sales].[Customers] cus on ord.custid = cus.custid
where cus.city = emp.city


---- N12 ----- 

select DISTINCT cus.contactname from [Sales].[Customers] cus 
join [Sales].[Orders] ord on cus.custid = ord.custid
join [Sales].[OrderDetails] orddet on orddet.orderid = ord.orderid
join [Production].[Products] prod on prod.productid = orddet.productid
join [Production].[Categories] cat on cat.categoryid = prod.categoryid
where cat.categoryname in ('Beverages','Dairy Products')


use [Hardware]

select * from [dbo].[Manufacturers]

select * from [dbo].[Products]
---- N1 -----

select * from [dbo].[Products] where ManufacturerId=
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name = 'Hewlett-Packard'
)


---- N2 -----

select prod.Name,prod.Price from [dbo].[Products] prod where 
ManufacturerId not in 
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name in ('Fujitsu')
)

---- N3 -----

select prod.Name,prod.Price from [dbo].[Products] prod where 
ManufacturerId in 
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name  in ('Fujitsu','Sony','IBM','Intel')
)

---- N4 -----


select * from [dbo].[Manufacturers] man
where man.ManufacturerId in 
(
select ManufacturerId from [dbo].[Products] prod 
where prod.Price > 200
)

---- N5 -----

select * from [dbo].[Products] prod 
where ManufacturerId in 
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name not in ('Dell','Genius')
)

---- N6 -----

select Distinct count(man.ManufacturerId) as QuantityOfManufactors from [dbo].[Manufacturers] man
where man.ManufacturerId in 
(
select ManufacturerId from [dbo].[Products] prod
where prod.Name LIKE ('%drive')
)

---- N7 -----

select count(*) from [dbo].[Products] prod
where prod.ManufacturerId  in
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name = 'Intel'
) and 
prod.Price >
(
select AVG(Price) from [dbo].[Products]
where ManufacturerId in 
(
select ManufacturerId from [dbo].[Manufacturers] man
where man.Name = 'Intel'
)
)


use [WorldEvents]


---- N1 -----

select Count(*) from [dbo].[Event]
where CountryID in
(
select CountryID  from [dbo].[Country] c
where c.ContinentID in 
(
select ContinentID from [dbo].[Continent] con
where con.ContinentName = 'Europe'
)
)


---- N2 -----

select MIN(e.EventDate) from [dbo].[Event] e
join [dbo].[Country] c on c.CountryID = e.CountryID
join [dbo].[Continent] cont on cont.ContinentID = c.ContinentID
where cont.ContinentName = 'Africa'

---- N3 -----

select COUNT(*) from [dbo].[Country] c
join [dbo].[Continent] cont on cont.ContinentID = c.ContinentID
where cont.ContinentName in ('North America','South America')


---- N4 -----

select COUNT(*) from [dbo].[Event] e
join [dbo].[Category] c on c.CategoryID = e.CategoryID
where c.CategoryName = 'Economy'
and MONTH(e.EventDate) = 1
and DAY(e.EventDate) = 1


---- N5 -----

select MAX(e.EventDate) from [dbo].[Event] e
join [dbo].[Category] cat on cat.CategoryID = e.CategoryID
join  [dbo].[Country] cou on cou.CountryID = e.CountryID
join [dbo].[Continent] cont on cont.ContinentID = cou.ContinentID
where cat.CategoryName = 'Sports' and cont.ContinentName = 'Europe'


