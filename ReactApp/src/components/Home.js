import React, { PureComponent } from "react";
import ReactTable from 'react-table'
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { Button, Form } from "semantic-ui-react";
import { get_employees } from "../actions/actions";
import 'react-table/react-table.css';

class Home extends PureComponent {
  constructor(props) {
    super(props);
    this.state = {
      id:''
    };
    this.handleChange = this.handleChange.bind(this);
  }
  handleChange = (e, { name, value }) => this.setState({ [name]: value });
  render() {
    const columns = [{
        Header: 'Id',
        accessor: 'Id' // String-based value accessors!
      }, {
        Header: 'Name',
        accessor: 'Name'
      }, {
        Header: 'Contract Type',
        accessor: 'ContractTypeName'
      }, {
        Header: 'Contract Type',
        accessor: 'ContractTypeName'
      }, {
        Header: 'Role',
        accessor: 'RoleName'
      }, {
        Header: 'Hourly Salary',
        accessor: 'HourlySalary'
      }, {
        Header: 'Monthly Salary',
        accessor: 'MonthlySalary'
      }, {
        Header: 'Annual Salary',
        accessor: 'AnnualSalary'
      }]
    const { employees, get_employees } = this.props;
    console.log(employees);
    return (
      <div className="ui center aligned segment">
        <Form onSubmit={null}>
          <Form.Field>
            <Form.Input
              type="text"
              placeholder="Please enter Id"
              name="id"
              value={this.state.id}
              onChange={this.handleChange}
            />
          </Form.Field>
          <Form.Field>
            <div className="ui two buttons">
              <Button
                basic
                onClick={() => get_employees(this.state.id)}
                color="red"
              >
                GET EMPLOYEES
              </Button>
            </div>
          </Form.Field>
        </Form>
        <ReactTable
    data={employees}
    columns={columns}
    defaultPageSize={5}
  />
      </div>
    );
  }
}

const mapStateToProps = state => ({
  employees: state.employees
});

const mapDispatchToProps = dispatch =>
  bindActionCreators(
    {
      get_employees
    },
    dispatch
  );

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Home);
