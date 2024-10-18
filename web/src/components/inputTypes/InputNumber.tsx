import Form from "react-bootstrap/esm/Form";
import { FormField } from "../../models/GetCompanyFormResponse";

interface NumberInputProps {
    formField: FormField;
    id: string;
}

const InputNumber = (props: NumberInputProps) => {
    const getPattern = () => {
        const validation = props.formField.validation;

        if (!validation || !validation.pattern) {
            return undefined;
        }
        return validation.pattern;
    }

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
            <Form.Control type="number" pattern={getPattern()} required={getRequired()}/>
        </Form.Group>
    );
};

export default InputNumber;
