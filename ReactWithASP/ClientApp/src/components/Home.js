import React from 'react';
import styles from "./Home.module.css";

export const Home = () => {
  return (
    <div className={styles.container}>
      <h1 className={styles.title}>Welcome to Daisy Project</h1>
      <p className={styles.description}>
        This is the home screen of our React & ASP.NET Core project.
      </p>
    </div>
  );
};
