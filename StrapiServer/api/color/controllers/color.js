'use strict';

/**
 * Read the documentation (https://strapi.io/documentation/developer-docs/latest/development/backend-customization.html#core-controllers)
 * to customize this controller
 */

module.exports =
{
  async getRandom(ctx)
  {

    const colors = await strapi.services.color.find(); // Fetch all colors
    const randomColor = colors[Math.floor(Math.random() * colors.length)];   // Select a random color
    return randomColor;  // Return the random color
  },
};
