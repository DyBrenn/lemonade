import { useMemo, useState } from "react";
import styled from "styled-components"
import { Button, Columns, Form, Heading, Modal } from "react-bulma-components";
import { gql, useMutation, useQuery } from "@apollo/client";
import Drink from "./Drink";

const DRINKS_QUERY = gql`
  query GET_DRINKS {
    drinksFromEF {
      id,
      flavor,
      price,
      size
    }
  }
`;

const DRINKS_MUTATION = gql`
  mutation CREATE_DRINK($flavor: String!, $size: String!, $price: Decimal!) {
    createDrink(flavor: $flavor, size: $size, price: $price) {
      id,
      flavor,
      size,
      price
    }
  }
`;

const ORDER_MUTATION = gql`
  mutation CREATE_ORDER($name: String!, $contact: String!, $price: Decimal!, $drinkIds: [String]!) {
    createOrder(name: $name, contact: $contact, price: $price, drinkIds: $drinkIds) {
      name,
      contact,
      price,
      drinkIds
    }
  }
`;

const StyledDiv = styled.div`
  display:flex;
  background-color: #F5F5F5;
  padding: 15px;
  margin: 5px;
  margin-top:50px;
  padding-top: 50px;
  padding-bottom: 50px;
`

const TotalDiv = styled.div`
  text-align: right;
  margin-left: auto;
`
const CheckoutDiv = styled.div`
  background-color: #F5F5F5;
  text-align: right;
  margin-left: auto;
`

const OrderButton = styled.button`
  width: 100%;
`

const ModalDiv = styled.div`
  background-color: white;
`

const StyledDiv2 = styled.div`
  background-color: #F5F5F5;
  padding: 5px;
  margin: 2px;
`

function mapToDataDrinks(data: any): Array<any> {
  console.log(data);
  if (data && Array.isArray(data.drinksFromEF)) {
    return data.drinksFromEF;
  }
  return [];
}

const Page = () => {
  const { loading, data, refetch } = useQuery(DRINKS_QUERY);
  const [createDrink] = useMutation(DRINKS_MUTATION);
  const [createOrder] = useMutation(ORDER_MUTATION);
  const [countTotal, setCountTotal] = useState(0)
  const [modal, setModal] = useState(false)
  const [name, setName] = useState("")
  const [contact, setContact] = useState("")
  const [drinkList, setDrinkList] = useState<string[]>([])

  console.log(drinkList)

  const getDataList = useMemo(() => mapToDataDrinks(data), [data]);

  const populateDatabase = async () => {
    await createDrink({
      variables: {
        flavor: "Lemonade",
        price: 1.00,
        size: "Regular"
      }
    });

    await createDrink({
      variables: {
        flavor: "Pink Lemonade",
        price: 1.00,
        size: "Regular"
      }
    });

    await createDrink({
      variables: {
        flavor: "Lemonade",
        price: 1.50,
        size: "Large"
      }
    });

    await createDrink({
      variables: {
        flavor: "Pink Lemonade",
        price: 1.50,
        size: "Large"
      }
    });
    window.location.reload();
  }

  const rendarModal = () => {
    setModal(!modal)
  }

  const order = async () => {
    await createOrder({
      variables: {
        name,
        price: countTotal,
        contact,
        drinkIds: drinkList
      }
    });
    rendarModal()
  }

  const renderColumn = () => {
    if (getDataList.length !== 0){
      return (
        <StyledDiv2>
          <Columns>
            <Columns.Column>
            </Columns.Column>
            <Columns.Column>
            </Columns.Column>
            <Columns.Column>
              Price
            </Columns.Column>
            <Columns.Column>
              QTY
            </Columns.Column>
            <Columns.Column>
              Total
            </Columns.Column>
          </Columns>
        </StyledDiv2>
      )
    }
  }

  const renderDrinks = () => {
    if (getDataList.length !== 0){
      return getDataList.map(drink => {
        return(
          <Drink
          id = {drink.id}
          flavor = {drink.flavor}
          price = {drink.price}
          size = {drink.size}
          countTotal = {countTotal}
          setCountTotal = {setCountTotal}
          drinkList = {drinkList}
          setDrinkList = {setDrinkList}
          />
        )
      });
    } else {
      console.log("OKAskljdsajld")
      return(
        <Button className="button is-primary" onClick={populateDatabase}>Populate database with drinks</Button>
      )
    }
  }

  return (
    <Columns>
      <Modal show={modal} onClose={rendarModal}>
        <ModalDiv>
        <Form.Field>
            <Form.Control>
              <Form.Input
                value={name}
                placeholder="name"
                onChange={(e) => setName(e.target.value)}
              />
            </Form.Control>
            <Form.Control>
              <Form.Input
                value={contact}
                placeholder="email or number"
                onChange={(e) => setContact(e.target.value)}
              />
            </Form.Control>
          </Form.Field>
          <OrderButton className="button is-primary" onClick={order}>Place your order</OrderButton>
        </ModalDiv>
      </Modal>
      <Columns.Column className="is-three-quarters">
      {renderColumn()}
      {renderDrinks()}
      </Columns.Column>
      <Columns.Column>
        <CheckoutDiv>
          <StyledDiv>
          Total
          <TotalDiv>${countTotal.toFixed(2)}</TotalDiv>
          </StyledDiv>
          <OrderButton className="button is-black" onClick={rendarModal}>Checkout</OrderButton>
        </CheckoutDiv>
      </Columns.Column>
    </Columns>
  );
}

export default Page;