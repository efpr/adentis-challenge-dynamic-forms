export interface GetCompanyFormResponse {
    name:       string;
    formFields: FormField[];
}

export interface FormField {
    label:      string;
    type:       string;
    validation: Validation;
    options:    string[] | null;
}

export interface Validation {
    required: boolean;
    pattern:  string | null;
}
