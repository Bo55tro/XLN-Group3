import React, { Component } from 'react';
import styles from "./Home.module.css";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div className={styles.container}>
      <h1 className={styles.title}>Welcome to Daisy Project</h1>
      <p className={styles.description}>
        This is the home screen of our React & ASP.NET Core project.
      </p>
    </div>
    );
  }
}
