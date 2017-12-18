import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface ICountry {
    name: string;
}

interface ICity {
    name: string;
}

interface IRegister {
    countries: ICountry[];
    cities: ICity[];

    name: string;
    password: string;
    confirmPassword: string;
    email: string;
    city: string;
    country: string;
}

export class Register extends React.Component<RouteComponentProps<{}>, IRegister> {
    constructor() {
        super();
        this.state = {
            countries: [],
            cities: [],

            name: "",
            password: "",
            confirmPassword: "",
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
        fetch('api/users', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                "name": this.state.name,
                "password": this.state.password,
                "email": this.state.email,
                "city": this.state.city
            })
        })
    }

    public render() {
        let registerForm = this.renderRegisterForm();

        return (
            <div className="container">
                <div className="register-box">
                    <div className="row">
                        <div className="col-xs-12">
                            <h2 className="register-title">Register New Account</h2>
                        </div>
                    </div>
                            {registerForm}
                </div>
            </div>
        );
    }

    private renderRegisterForm() {
        return (
            <form className="register-box-margin">
                <div className="center">
                    <div className="row">
                        <div className="col-xs-12">
                            <div className="input-group input-group-custom input-group-icon">
                                <input
                                    value={this.state.name}
                                    onChange={this.onChange}
                                    placeholder="Your Name"
                                    name="name"
                                    required
                                    type="text" />
                                <div className="input-icon"><i className="glyphicon glyphicon-user"></i></div>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-xs-12">
                            <div className="input-group input-group-custom input-group-icon">
                                <input
                                    value={this.state.email}
                                    onChange={this.onChange}
                                    placeholder="Email Address"
                                    name="email"
                                    required
                                    type="email" />
                                <div className="input-icon"><i className="glyphicon glyphicon-envelope"></i></div>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-xs-12">
                            <div className="input-group input-group-custom input-group-icon">
                                <input
                                    value={this.state.password}
                                    onChange={this.onChange}
                                    required
                                    placeholder="Password"
                                    name="password"
                                    type="password" />
                                <div className="input-icon"><i className="glyphicon glyphicon-lock"></i></div>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-xs-12">
                            <div className="input-group input-group-custom input-group-icon">
                                <input
                                    value={this.state.confirmPassword}
                                    onChange={this.onChange}
                                    placeholder="Confirm Password"
                                    name="confirmPassword"
                                    type="password" />
                                <div className="input-icon"><i className="glyphicon glyphicon-lock"></i></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-xs-12 col-sm-6">
                        <div className="input-group country-box">
                            {
                                this.renderCountries()
                            }
                        </div>
                    </div>
                   <div className="col-xs-6 col-sm-6">
                        <div className="input-group">
                            {
                                this.renderCities()
                            }
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12 terms-align">
                        <h4 className="terms-title">Terms and Conditions</h4>
                        <div className="input-group">
                            <input type="checkbox" id="terms" />
                            <label htmlFor="terms">I accept the terms and conditions for signing up.</label>
                        </div>
                    </div>
                </div>
                <button className="generic-button" onClick={this.onSubmit}>Register</button>
            </form>
            );
    }

    private renderCountries() {
        return (
            <select
                defaultValue="country"
                name="country"
                onChange={this.getCitiesByCountry}
                value={this.state.country}>
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
                value={this.state.city}
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