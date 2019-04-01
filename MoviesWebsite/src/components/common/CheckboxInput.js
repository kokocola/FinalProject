import React, {PropTypes} from 'react';

const NumberInput = ({name, label, onChange, value, error}) => {

    let wrapperClass= 'form-check';

    if (error && error.length > 0) {
        wrapperClass += " " + 'has-error';
    }

    return (
        <div className={wrapperClass}>
            <label htmlFor={name}>{label}</label>
            <input
                type="checkbox"
                className="form-check-input"
                checked={value}
                onChange={onChange} />
            {error && <div className="alert alert-danger">{error}</div>}
        </div>
    );
};

NumberInput.propTypes = {
    name: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    value: PropTypes.bool,
    error: PropTypes.string
};

export default NumberInput;