package mpt.ru.mar.practic.ui.list;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;

import mpt.ru.mar.practic.R;
import mpt.ru.mar.practic.RecyclerItemClickListener;
import mpt.ru.mar.practic.ui.placeholder.PlaceholderContent;

/**
 * A fragment representing a list of Items.
 */
public class ItemFragment extends Fragment {

    // TODO: Customize parameter argument names
    private static final String ARG_COLUMN_COUNT = "column-count";
    // TODO: Customize parameters
    private int mColumnCount = 1;

    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public ItemFragment() {
    }

    // TODO: Customize parameter initialization
    @SuppressWarnings("unused")
    public static ItemFragment newInstance(int columnCount) {
        ItemFragment fragment = new ItemFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_COLUMN_COUNT, columnCount);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments() != null) {
            mColumnCount = getArguments().getInt(ARG_COLUMN_COUNT);
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode==-1) {
            Bundle bundle = data.getExtras();
            double result = bundle.getDouble("result", -1.0);
            int code = bundle.getInt("code", -1);
            saveText(code, result);
        }
    }

    void saveText(int code, double result) {
        SharedPreferences sPref = requireActivity().getPreferences(Context.MODE_MULTI_PROCESS);
        SharedPreferences.Editor ed = sPref.edit();
        ed.putString(String.valueOf(code), String.valueOf(result));
        ed.apply();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_item_list, container, false);
        RecyclerView recyclerView = view.findViewById(R.id.list);
        Context context = recyclerView.getContext();
        if (mColumnCount <= 1) {
            recyclerView.setLayoutManager(new LinearLayoutManager(context));
        } else {
            recyclerView.setLayoutManager(new GridLayoutManager(context, mColumnCount));
        }
        recyclerView.setAdapter(new MyItemRecyclerViewAdapter(PlaceholderContent.ITEMS));
        recyclerView.addOnItemTouchListener(
                new RecyclerItemClickListener(context, recyclerView, new RecyclerItemClickListener.OnItemClickListener() {
                    @Override
                    public void onItemClick(View view, int position) {
                        View originView = (View) view.getParent().getParent();
                        String ageText = ((EditText) originView.findViewById(R.id.editTextAge)).getText().toString();
                        if (ageText.equals(""))
                            return;

                        PlaceholderContent.PlaceholderItem test = PlaceholderContent.ITEMS.get(position);
                        Intent intent = new Intent(getContext(),
                                test.view);

                        intent.putExtra("gender", ((Spinner) originView.findViewById(R.id.spinner)).getSelectedItem().toString().equals("Мужчина") ? 1 : 2);

                        intent.putExtra("age", Integer.parseInt(ageText));

                        intent.putExtra("code", Integer.parseInt(test.id));

                        intent.putExtra("values", test.values);
                        intent.putExtra("des", test.des.toArray());

                        startActivityForResult(intent, 0);
                    }

                    @Override
                    public void onLongItemClick(View view, int position) {
                        // do whatever
                    }
                })
        );

        Spinner spinner = view.findViewById(R.id.spinner);
        String[] gender = {"Мужчина", "Женщина"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, gender);
        // Определяем разметку для использования при выборе элемента
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        // Применяем адаптер к элементу spinner
        spinner.setAdapter(adapter);


        return view;
    }
}