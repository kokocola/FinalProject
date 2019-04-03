import React, {PropTypes} from 'react';
import TextInput from './TextInput';

const SearchBar = ({name, label, onChange, onClick, placeholder, value, error}) => {

    return (
        <form className="row">
            <TextInput
                name={name}
                label={label}
                onChange={null}
                value={value}
                placeholder={placeholder}
                error={error}
                onChange={onChange}
            />
            <input
                    type="submit"
                    value={label}
                    className="btn btn-primary col-4"
                    onClick={onClick} />
        </form>
    );
};

SearchBar.propTypes = {
    name: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    placeholder: PropTypes.string,
    value: PropTypes.number,
    error: PropTypes.string
};

export default SearchBar;