import Form from "react-bootstrap/esm/Form";
import { FormField } from "../../models/GetCompanyFormResponse";

interface InputDateProps {
    formField: FormField;
    id: string;
}

const InputDate = (props: InputDateProps) => {
    const getRequired = () => {
        const validation = props.formField.validation;
        if (!validation) {
            return false;
        }
        return validation.required;
    }

    return (
        <Form.Group className="mb-3" controlId={props.id}>
            <Form.Label>{props.formField.label}</Form.Label>
            <Form.Control type="date" required={getRequired()}/>
        </Form.Group>
    );
};

export default InputDate;
