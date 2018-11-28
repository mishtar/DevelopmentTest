import { GET_EMPLOYEES } from '../actions/actions';

const initialState = {employees: []};
const reducer = (state=initialState, action) => {
    switch(action.type){
        case GET_EMPLOYEES:
            console.log(action.payload);
            return {...state, employees: action.payload};
        default:
            return state;
    }
}

export default reducer;
