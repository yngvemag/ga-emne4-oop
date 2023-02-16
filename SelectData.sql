SELECT customerNumber 'CustomerNumber',
		customerName 'CustomerName', #,replace(customerName,',','') 'CustomerName',
        phone 'Phone',
        addressline1 'Address ',#replace(addressLine1,',','') 'Address', 
        city 'City',
        country 'Country'
FROM classicmodels.customers;


SELECT 	c.customerName, 
		p.*
FROM classicmodels.payments p
inner join classicmodels.customers c on c.customerNumber = p.customerNumber
order by amount desc;



SELECT employeeNumber,
		firstName,
        lastName,
        email,
        jobTitle
FROM classicmodels.employees;