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

