import React from 'react';
import TextInput from '../common/TextInput';
import SelectInput from '../common/SelectInput';

const MovieForm = ({movie, onSave, onChange, saving, errors}) => {
    return (
        <form>
            <h1>Manage Movie</h1>
            <TextInput
                name="title"
                label="Title"
                value={movie.title}
                onChange={onChange}
                error={errors.title}
            />
            <TextInput
                name="category"
                label="Category"
                value={movie.category}
                onChange={onChange}
                error={errors.category}
            />
            <TextInput
                name="length"
                label="Length"
                value={movie.length}
                onChange={onChange}
                error={errors.length}
            />
            <input
                type="submit"
                disabled={saving}
                value={saving ? 'Saving...' : 'Save'}
                className="btn btn-primary"
                onClick={onSave}
            />
        </form>
    );
};

MovieForm.propTypes = {
    movie: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onChange: React.PropTypes.func.isRequired,
    saving: React.PropTypes.bool,
    errors: React.PropTypes.object
};

export default MovieForm;