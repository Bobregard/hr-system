# hr-system
![example workflow](https://github.com/Bobregard/hr-system/actions/workflows/dotnet.yml/badge.svg)
System to store jobs and apply for a job functionality

Main functionalities:
- As a default user, when I navigate to the jobs page, I want to see all available jobs.

- As a default user, I want to be able to register in the website.

- As a default or logged in user, I want to be able to apply for a job.

- As an HR, I want to be able to see all people who applied for a position.

Jobs (public):
- have a page with all available jobs. 
- job details: category; company name; company description; company logo; job requirements; benefits; action button "Apply" (available for all users)
- if the user has a profile (and logged in) populate applicant data automatically

Jobs (private):
- CRUD operations for each job
- isActive flag
- view number of people who applied
- view applicants for job
- ability to highlight (with stars) approved applicants

User Profile:
- CV:
	+ option to add experience (infinite additions)
- contacts

Applicants:
- if an applicant is a logged in user, populate data automatically

* default user is a user who is not logged in
* logged in user can be a job applicant, HR or admin

Epics:
1. User profile
1.1 Ability to register
1.2 Ability to CRUD contacts data
1.3 Ability to CRUD CV data

2. Jobs (private)
2.1 Create jobs
2.2 Update jobs
2.3 View jobs
2.4 Delete jobs
2.5 isActive flag
2.6 view number of people who applied
2.7 view applicants
2.8 hihglight approved candidates

3. Jobs (public)
3.1 view all jobs
3.2 view details
3.3 apply for a job
3.3.1 populate data for users with profiles

Test
