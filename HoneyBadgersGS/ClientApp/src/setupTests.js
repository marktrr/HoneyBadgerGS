
import { HoneyBadgerUrl } from 'src/Constants';


const localStorageMock = {
  getItem: jest.fn(),
  setItem: jest.fn(),
  removeItem: jest.fn(),
  clear: jest.fn(),
};
global.localStorage = localStorageMock;

// Mock the request issued by the react app to get the client configuration parameters.
window.fetch = () => {
  return Promise.resolve(
    {
      ok: true,
          json: () => Promise.resolve({
              "authority": HoneyBadgerUrl,
              "client_id": "HoneyBadgers._0",
              "redirect_uri": HoneyBadgerUrl + "/authentication/login-callback",
              "post_logout_redirect_uri": HoneyBadgerUrl + "/authentication/logout-callback",
        "response_type": "id_token token",
        "scope": "HoneyBadgers._0API openid profile"
     })
    });
};
