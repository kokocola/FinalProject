import React from 'react';
import TextInput from '../common/TextInput';
import NumberInput from '../common/NumberInput';
import CheckboxInput from '../common/CheckboxInput';
import SelectInput from '../common/SelectInput';

const MovieForm = ({movie, onSave, onChange, saving, errors, onDelete}) => {
    return (
        <form>
            <h1>Manage Movie</h1>
            <TextInput
                name="titleType"
                label="Title Type"
                value={movie.titleType}
                onChange={onChange}
                error={errors.titleType}
            />
            <TextInput
                name="primaryTitle"
                label="Primary Title"
                value={movie.primaryTitle}
                onChange={onChange}
                error={errors.primaryTitle}
            />
            <TextInput
                name="originalTitle"
                label="Original Title"
                value={movie.originalTitle}
                onChange={onChange}
                error={errors.originalTitle}
            />
            <CheckboxInput
                name="isAdult"
                label="Is Adult"
                value={movie.isAdult}
                onChange={onChange}
                error={errors.isAdult}
            />
            <NumberInput
                name="startYear"
                label="Start Year"
                value={movie.startYear}
                onChange={onChange}
                error={errors.startYear}
            />
            <NumberInput
                name="endYear"
                label="End Year"
                value={movie.endYear}
                onChange={onChange}
                error={errors.endYear}
            />
            <NumberInput
                name="runTimeMinutes"
                label="Runtime Minutes"
                value={movie.runTimeMinutes}
                onChange={onChange}
                error={errors.runTimeMinutes}
            />
            <TextInput
                name="genre"
                label="Genre"
                value={movie.genre}
                onChange={onChange}
                error={errors.genre}
            />
            <input
                type="submit"
                disabled={saving}
                value={saving ? 'Saving...' : 'Save'}
                className="btn btn-primary"
                onClick={onSave}
            />
            <button
                className="btn btn-danger"
                onClick={onDelete}>
                Remove Movie
            </button>
        </form>
    );
};

MovieForm.propTypes = {
    movie: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onChange: React.PropTypes.func.isRequired,
    saving: React.PropTypes.bool,
    errors: React.PropTypes.object,
    onDelete: React.PropTypes.func.isRequired
};

export default MovieForm;