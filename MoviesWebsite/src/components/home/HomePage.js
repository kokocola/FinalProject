import React from 'react';
import {Link} from 'react-router';

class Homepage extends React.Component {
    render() {
        return (
            <div className="jumbotron">
                <h1>Movies Website</h1>
                <p>Show the IMDB Database</p>
                <Link to="about" className="btn btn-primary btn-lg">Learn More</Link>
            </div>
        );
    }
}

export default Homepage;