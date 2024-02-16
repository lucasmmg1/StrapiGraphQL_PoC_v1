module.exports = {
  definition: `
    extend type Query {
      getRandomColor: Color!
    }
  `,
  resolver: {
    Query: {
      getRandomColor: {
        resolver: 'color.getRandom'
      }
    }
  }
};
