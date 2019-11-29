import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';
import { Profile } from '../Profile/profile.component';


export class LoginMenu extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null,
            userId: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name,
            userId: user && user.sub
        });
        if (user !== null) {
            var timer = new Date();
            timer.setTime(timer.getTime() * 1 * 3600 * 1000);

            document.cookie =
                'userId=' + (this.state.userId + ',' + this.state.userName) +
                '; expires=' + timer.toUTCString() +
                '; path=/';
        }
    }

    render() {
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath);
        }
    }

    authenticatedView(userName, profilePath, logoutPath) {
        return (<Fragment>
            <NavItem>
                <NavLink tag={Link} className="text-light" to={"/Profile"}>Profile</NavLink>
            </NavItem>
            <NavItem>
                    <NavLink tag={Link} className="text-light" to='/FriendList'>Friends</NavLink> 
            </NavItem>
            <NavItem>
                <NavLink tag={Link} className="text-light" to={profilePath}>Hello, {userName}</NavLink>
            </NavItem>
            <NavItem>
                <NavLink tag={Link} className="text-light" to={logoutPath}>Logout</NavLink>
            </NavItem>
        </Fragment>);

    }

    anonymousView(registerPath, loginPath) {
        return (<Fragment>
            <NavItem>
                <NavLink tag={Link} className="text-light" to={registerPath}>Register</NavLink>
            </NavItem>
            <NavItem>
                <NavLink tag={Link} className="text-light" to={loginPath}>Login</NavLink>
            </NavItem>
        </Fragment>);
    }
}
