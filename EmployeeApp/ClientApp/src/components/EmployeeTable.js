import React, { useEffect, useState, useRef } from 'react';
import {
    InputGroup,
    InputGroupAddon,
    Input,
    Button,
    Table
   } from 'reactstrap';
   import '../custom.css';
export default function EmployeeTable(props) {

const inputEl = useRef(null);
const [employees, setEmployees] = useState(null);
const [isLoading, setisLoading] = useState(true);
useEffect(async () => {
    await fetchEmployees('api/employees');
    setisLoading(false);
}, [])

const fetchEmployees = async (url) => {
    await fetch(url).then(async(response) => {
        if (response.ok && response.status === 200) {
            const data = await response.json();
            const employeeArray = Array.isArray(data) ? data : [data];
            setEmployees(employeeArray);
        }
        else
        {
            setEmployees([]); 
        }
    });
}
const  handlerOnSearchButtonClick = async (e) =>{
    let url;
    inputEl.current.value ? url = `api/employees/${inputEl.current.value}` : url = 'api/employees';
    fetchEmployees(url);
}
    return (
        isLoading ? <p><em>Loading...</em></p> :
        <>
        <InputGroup className={"search-control"}>
        <InputGroupAddon addonType="prepend"><Button onClick={(e) =>handlerOnSearchButtonClick(e)}>Search</Button></InputGroupAddon>
        <Input innerRef={inputEl} />
        </InputGroup>
        <Table bordered>
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Anual Salary</th>
              <th>Role Id</th>
              <th>Role Name</th>
              <th>Role Description</th>
            </tr>
          </thead>
          <tbody>
            {employees.map(employee =>
              <tr key={employee.id}>
                <td>{employee.id}</td>
                <td>{employee.name}</td>
                <td>{`$${employee.anualSalary}`}</td>
                <td>{employee.roleId}</td>
                <td>{employee.roleName}</td>
                <td>{employee.roleDescription}</td>
              </tr>
            )}
          </tbody>
        </Table>
        </>
      );
}
