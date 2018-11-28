import axios from "axios";
import { GetEmployees } from "../Endpoints/endpoints";

export const GET_EMPLOYEES = "GET_EMPLOYEES";
export function get_employees(id) {
  return function(dispatch) {
    axios.get(`${GetEmployees}${ id !== '' ? `?id=${id}` : ''}`).then(employees => {
      if (employees.status === 200) {
        dispatch({
          type: GET_EMPLOYEES,
          payload: employees.data
        });
      }
    });
  };
}
