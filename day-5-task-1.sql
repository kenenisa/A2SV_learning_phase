# Question 1: https://leetcode.com/problems/combine-two-tables/description/
SELECT firstName, lastName,city,state 
FROM Person
LEFT OUTER JOIN Address
ON Person.personId = Address.personId

# Question 2: https://leetcode.com/problems/big-countries/
SELECT name,population,area
FROm World
WHERE area >= 3000000 OR population >= 25000000

# Question 3: https://leetcode.com/problems/duplicate-emails/
SELECT email
FROM Person
GROUP BY email
HAVING COUNT(email) > 1

# Question 4: https://leetcode.com/problems/customers-who-never-order/
SELECT
    name AS Customers
FROM
    Customers A
LEFT JOIN Orders B ON B.customerId = A.id
WHERE B.customerId IS NULL

# Question 5: https://leetcode.com/problems/employees-earning-more-than-their-managers/description/
SELECT name AS Employee
FROM Employee employee
WHERE salary > (
    SELECT manager.salary
    FROM Employee manager
    WHERE manager.id = employee.managerId
);

# Question 6: https://leetcode.com/problems/consecutive-numbers/description/
SELECT DISTINCT num AS ConsecutiveNums 
FROM Logs
WHERE 
(id+1,num) IN (SELECT * FROM Logs)
AND
(id+2,num) in (SELECT * FROM Logs)

# Question 7: https://leetcode.com/problems/department-highest-salary/submissions/1058935334/
SELECT D.name AS Department, E.name AS Employee, E.salary AS Salary
FROM (SELECT * FROM Employee
WHERE (salary,departmentId) in (SELECT * FROM (
  SELECT MAX(salary) AS salary,departmentId FROM Employee
  GROUP BY departmentId
) AS X)) AS E
LEFT JOIN Department AS D
ON E.departmentId = D.id;


