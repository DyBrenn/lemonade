import { Container, Heading, Section } from "react-bulma-components";
import Page from "./Page";
import lemonade from'./lemonade.jpeg';
import styled from "styled-components";

const StyledImg= styled.img`
  display: block;
  margin-left: auto;
  margin-right: auto;
`


const App = () => {
  return (
    <div className="App">
      <Section>
        <Container>
          <StyledImg src={lemonade} alt="lemon"/>
          <Page />
        </Container>
      </Section>
    </div>
  );
}

export default App;
