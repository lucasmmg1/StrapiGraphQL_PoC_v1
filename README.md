# READ ME

# Proof of Concept: Strapi server with GraphQL query
This is a proof of concept made for testing a GraphQL query made to a Strapi in order to retrieve a random color and change a cube's material in an Unity project.

<h2> Goals </h2>
<p>
	This POC had two main goals: <br>
	<b> 1: To create a Strapi server and add some entries related to colors. </b> <br>
	<b> 2: To create a Unity project that would make a GraphQL query and use the result to change a cube's color. </b> <br>
</p>

<h2> Problems </h2>
<h4> <p> Problem 1: The NPM version </p> </h4>
<p>
  The NPM version that I had wasn't the right one, so the Strapi was giving me some errors. What I had to do was change the 
  NPM version to 14.21.3, based on the NPM version listed on the package-lock.json.
</p>

<h2> Achieved </h2>
<p>
  All of the goals were achieved.
</p>

<h2> Steps </h2>
<p> Strapi installation: run the following command: npm install strapi@latest -g </p>
<p> Creation of the project: run the following command and press enter into every step: strapi new StrapiServer </p>
<p> Entering the folder: just enter the folder with the following command: cd StrapiServer </p>
<p> Project's build: run the following command: npm run build </p>
<p> Enter the [admin webpage](http://localhost:1337/admin) and create an admin profile </p>
<p> Install the GraphQL: run the following command: npm install --save graphql </p>
<p> Enter the admin's Content-Types Builder and create the color type. </p>
<p> Add the colors according to your desire. </p>

<h2> Observations </h2>
<p> When downloading the repository, remeber to enter the StrapiServer folder via command line and run the following commands: npm install and npm run develop </p>
