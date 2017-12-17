import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ICountry {
    name: string;
}

interface ICity {
    name: string;
}

class User {
    name: string;
    password: string;
    email: string;
    city: string;
    country: string;
}

interface IRegister {
    user: User;
    countries: ICountry[];
    cities: ICity[];
    name: string;
    password: string;
    email: string;
    city: string;
    country: string;
}

export class Register extends React.Component<RouteComponentProps<{}>, IRegister> {
    constructor() {
        super();
        let user = new User();
        this.state = {
            user: user,
            countries: [],
            cities: [],
            name: "",
            password: "",
            email: "",
            country: "",
            city: ""
        };

        fetch('api/countries')
            .then(response => response.json() as Promise<ICountry[]>)
            .then(data => {
                this.setState({ countries: data });
            });

        this.onChange = this.onChange.bind(this);
        this.getCitiesByCountry = this.getCitiesByCountry.bind(this);
        this.renderCountries = this.renderCountries.bind(this);
        this.renderCities = this.renderCities.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    public render() {
        let registerForm = this.renderRegisterForm();

        return <div>
            <h1>Register Page</h1>
            {registerForm}
        </div>;
    }

    private getCitiesByCountry(e: any) {
        fetch('api/cities')
            .then(response => response.json() as Promise<ICity[]>)
            .then(data => {
                this.setState({ cities: data });
            });

        this.onChange(e);
    }

    private onChange(e: any) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    private onSubmit() {
        this.state.user.name = this.state.name;
        this.state.user.password = this.state.password;
        this.state.user.email = this.state.email;
        this.state.user.country = this.state.country;
        this.state.user.city = this.state.city;

        fetch('api/users', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                User: this.state.user
            })
        })
    }

    private renderRegisterForm() {
        return (
            <form>
                <label htmlFor="name">Enter your name</label>
                <br />
                <input
                    value={this.state.user.name}
                    onChange={this.onChange}
                    name="name"
                    type="text" />
                <br />
                <label htmlFor="password">Enter your password</label>
                <br />
                <input
                    value={this.state.user.password}
                    onChange={this.onChange}
                    name="password"
                    type="password" />
                <br />
                <label htmlFor="email">Enter your email</label>
                <br />
                <input
                    value={this.state.user.email}
                    onChange={this.onChange}
                    name="email"
                    type="email" />
                <br />
                <label htmlFor="country">Select your country</label>
                <br />
                {
                    this.renderCountries()
                }
                <br />
                <label htmlFor="city">Select your city</label>
                <br />
                {
                    this.renderCities()
                }
                <br />
                <button onClick={this.onSubmit}>Register</button>
            </form>
            );
    }

    private renderCountries() {
        return (
            <select
                defaultValue="country"
                name="country"
                onChange={this.getCitiesByCountry}
                value={this.state.user.country}>
                <option value="country" disabled>Country</option>
                {
                    this.state.countries.map(country =>
                        <option
                            key={country.name}
                            name="country"
                            value={country.name}>{country.name}
                        </option>
                    )
                }
            </select>
        );
    }

    private renderCities() {
        return (
            <select
                defaultValue="city"
                name="city"
                value={this.state.user.city}
                onChange={this.onChange}>
                <option value="city" disabled>City</option>
                {
                    this.state.cities.map(city =>
                        <option
                            key={city.name}
                            value={city.name}>{city.name}
                        </option>
                    )
                }
            </select>
        );
    }
}