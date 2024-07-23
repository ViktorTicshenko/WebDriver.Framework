# Web Automation Project

## Overview

This project automates a script for interacting with the Google Cloud Platform's pricing calculator. The automation script follows a specific sequence of steps, fills out a form with predefined data, and verifies the result. The project includes the following components:

1. **WebDriver Manager**: Manages browser connectors.
2. **Page Object/Page Factory**: Provides abstractions for web pages.
3. **Models**: Represents business objects of the required elements.
4. **Property Files**: Contains test data for at least two different environments.
5. **Error Handling**: Takes a screenshot with date and time if the test fails.

## Precondition

This project builds on the previous assignment (Task 3) from the WebDriver module.

## Automated Script Steps

1. Open [Google Cloud Pricing Calculator](https://cloud.google.com/).
2. Click on "Add to estimate" button.
3. Select "Compute Engine".
4. Fill out the form with the following data:
   - **Number of instances**: 4
   - **Operating System / Software**: Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)
   - **Provisioning model**: Regular
   - **Machine Family**: General purpose
   - **Series**: N1
   - **Machine type**: n1-standard-8 (vCPUs: 8, RAM: 30 GB)
   - **Select “Add GPUs”**
   - **GPU type**: NVIDIA V100
   - **Number of GPUs**: 1
   - **Local SSD**: 2x375 Gb
   - **Region**: Netherlands (europe-west4)
   - Other options leave in the default state.
5. Click "Share" to see the Total estimated cost.
6. Click "Open estimate summary" to see the Cost Estimate Summary, which will open in a separate browser tab.
7. Verify that the 'Cost Estimate Summary' matches the values filled in Step 4.

## Project Structure

- **WebDriver Manager**: Manages the setup and configuration of browser drivers.
- **Page Objects/Page Factory**: Contains classes that represent web pages and their elements.
- **Models**: Defines the structure of business objects and data elements.
- **Property Files**: Stores test data for different environments.
- **Error Handling**: Includes functionality to take screenshots with timestamps if a test fails.


## Requirements
- .NET Framework or .NET Core
- NUnit framework
- Selenium WebDriver for .NET
- WebDriver-compatible browser (e.g., Chrome, Firefox, Edge)